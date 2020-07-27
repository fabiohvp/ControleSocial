<script>
  import Link from "../components/Navigation/Link.svelte";
</script>

<svelte:head>
  <title>CIDADES - PLATAFORMA PARA TRANSPARÊNCIA PÚBLICA</title>
</svelte:head>

<div class="bg-gray-200 w-full h-screen flex">
  <div class="m-auto w-full lg:w-1/2 p-8 rounded bg-white">
    <p class="text-3xl">Painel de Controle Social</p>
    <div>
      <p class="text-lg">
        Aqui você acompanha a aplicação do dinheiro público ES.
      </p>
      <p class="mt-4 text-blue-700">
        <Link href="/municipio/2020/001/consolidado/despesas" title="Despesas">
          Clique aqui para visualizar as Despesas
        </Link>
      </p>
      <p class="mt-2 text-blue-700">
        <Link href="/municipio/2020/001/consolidado/receitas" title="Receitas">
          Clique aqui para visualizar as Receitas
        </Link>
      </p>
    </div>
  </div>
</div>
