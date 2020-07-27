<script>
  import Modal from "../../../../../../components/Navigation/Modal.svelte";
  import Icon from "fa-svelte";
  import { faExclamationCircle } from "@fortawesome/free-solid-svg-icons/faExclamationCircle";
  import { faCheckCircle } from "@fortawesome/free-solid-svg-icons/faCheckCircle";
  import { faHistory } from "@fortawesome/free-solid-svg-icons/faHistory";

  import date, {
    meses,
    mesesAbreviados
  } from "../../../../../../utils/date.js";

  export let model;

  let loading = true;
  let possuiMesObrigatorio = false;
  let modalRef;
  let items;
  let omissoes;
  let ultimoItem;
  let ultimoSemOmissao;

  $: refresh(model);

  function refresh(model) {
    var hoje = new Date();
    hoje.setHours(0, 0, 0, 0);
    items = [];
    omissoes = [];
    ultimoItem = undefined;
    ultimoSemOmissao = undefined;

    if (!model) {
      return;
    }

    loading = false;
    for (let i = 0; i < 12; i++) {
      let item = { mes: i + 1 };

      if (model.value[i]) {
        item = { ...model.value[i] };

        if (item.dataLimite) {
          item.dataLimite = new Date(item.dataLimite);

          if (item.emOmissao) {
            item.emOmissao = true;
            omissoes.push(meses[i].toLocaleLowerCase());
          } else {
            item.dataHomologacao = new Date(item.dataHomologacao);
            if (!item.emTempo) {
              ultimoSemOmissao = item;
            }
          }
          ultimoItem = item;
        }
      }

      item.nomeMes = meses[i];
      item.nomeMesAbreviado = mesesAbreviados[i];
      items.push(item);
    }

    possuiMesObrigatorio = new Date() >= items[0].dataLimite;
    //para causar revalidação das variáveis
    items = items;
    omissoes = omissoes;
  }

  function getTooltip(item) {
    if (item.emDia) {
      return `Remessa recebida em dia (Data limite: ${date(
        item.dataLimite,
        "d/m/Y"
      )}, Data da entrega: ${date(item.dataHomologacao, "d/m/Y")})`;
    } else if (item.emAtraso) {
      return `Remessa recebida com atraso (Data limite: ${date(
        item.dataLimite,
        "d/m/Y"
      )}, Data da entrega: ${date(item.dataHomologacao, "d/m/Y")})`;
    } else if (item.emOmissao) {
      return `Remessa ainda não foi entregue  (Data limite: ${date(
        item.dataLimite,
        "d/m/Y"
      )})`;
    } else {
      return `Remessa ainda não obrigatória (Data limite: ${date(
        item.dataLimite,
        "d/m/Y"
      )})`;
    }

    return "Mês não exigível";
  }
</script>

<style>
  @media (min-width: 640px) {
    .modal-container :global(.modal) {
      width: 600px;
    }
  }
</style>

{#if loading}
  Carregando dados da prestação de contas...
{:else}
  <span on:click={() => modalRef.show()} class="cursor-pointer text-blue-800">
    {#if possuiMesObrigatorio || ultimoSemOmissao}
      Dados acumulados até
      <b>{ultimoSemOmissao.nomeMes.toUpperCase()}</b>
    {:else}
      <b>Não</b>
      há mês obrigatórios ainda
    {/if}
  </span>

  <div class="modal-container">
    <Modal bind:this={modalRef}>
      <span slot="header">Situação do envio de remessas ao TCE-ES</span>
      <hr class="mb-3" />

      <div class="w-full px-4 py-2 bg-gray-200 flex flex-wrap">
        {#each items as item, index}
          <div class="w-1/3 px-2 py-1" title={getTooltip(item)}>
            <div class="bg-gray-400 text-center p-3 border rounded">
              {#if item.emDia}
                <span class="text-green-600">
                  <Icon icon={faCheckCircle} />
                </span>
              {:else if item.emAtraso}
                <span class="text-yellow-600">
                  <Icon icon={faCheckCircle} />
                </span>
              {:else if item.emOmissao}
                <span class="text-red-800">
                  <Icon icon={faExclamationCircle} />
                </span>
              {:else}
                <span class="text-gray-600 rotate-x">
                  <Icon icon={faHistory} />
                </span>
              {/if}
              {item.nomeMesAbreviado}
            </div>
          </div>
        {/each}
      </div>

      {#if omissoes.length > 0}
        <p class="mt-2">
          Para o exercício de {ultimoItem.ano} estão pendentes as remessas de
          dados de PCM referentes a
          <b>{omissoes.join(', ')}</b>
          .
        </p>

        <p class="mt-2">
          <b>
            O prazo se encerrou em {date(ultimoItem.dataLimite, 'extenso')}.
          </b>
        </p>
      {:else}
        <p class="mt-2">
          Para o exercício de {ultimoItem.ano} não há remessas pendentes de
          dados de PCM junto ao TCE-ES.
        </p>
      {/if}
    </Modal>
  </div>
{/if}
