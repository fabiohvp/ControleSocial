<script>
  import Icon from "fa-svelte";
  import { faUsers } from "@fortawesome/free-solid-svg-icons/faUsers";
  import Loading from "../../../../../../../components/Navigation/Loading.svelte";
  import Widget from "../../../../../../../components/Widget/Widget.svelte";

  export let obrigacao;
</script>

<Widget noTooltip={true}>
  <span slot="title">Prefeitura Municipal</span>
  <div class="h-40 text-center">
    <span class="text-6xl">
      <Icon icon={faUsers} />
    </span>
    <div>
      {#if !obrigacao}
        <Loading />
      {:else if !obrigacao.value}
        Não há obrigação para prestação de conta deste ano
      {:else if obrigacao.value.situacao >= 0}
        Prestação de Contas Anual está em dia para a competência {obrigacao.value.ano}
      {:else}
        Prestação de Contas Anual está em atraso para a competência {obrigacao.value.ano}
      {/if}
    </div>
  </div>
</Widget>
