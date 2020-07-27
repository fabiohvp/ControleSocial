<script>
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import Series from "../../../../../../../components/Chart/Series.svelte";

  export let model;

  const grid = {
    left: 90
  };
  let series;
  let xAxis;

  const yAxis = [
    {
      type: "value",
      name: "Aplicação média nos municípios per capita",
      axisLabel: {
        formatter: "R$ {value}"
      }
    },
    {
      type: "value",
      name: "Aplicação per capita",
      axisLabel: {
        formatter: "R$ {value}"
      }
    }
  ];

  $: render(model);

  function render(model) {
    if (!model) {
      series = null;
      return;
    }

    const anos = [];
    const aplicacaoPerCapita = [];
    const mediaMunicipal = [];

    model.value.forEach(m => {
      anos.push(m.ano);
      aplicacaoPerCapita.push(m.aplicacaoPerCapita);
      mediaMunicipal.push(m.mediaMunicipal);
    });

    xAxis = [
      {
        type: "category",
        data: anos,
        axisPointer: {
          type: "shadow"
        }
      }
    ];

    series = [
      {
        type: "line",
        name: "Aplicação média nos municípios per capita",
        data: mediaMunicipal
      },
      {
        type: "bar",
        name: "Aplicação per capita",
        data: aplicacaoPerCapita
      }
    ];
  }
</script>

<Widget>
  <span slot="title">Evolução da aplicação em Receita Arrecadada X Saúde</span>
  <span slot="tooltip">
    Aplicação em saúde: recursos aplicados. Receita Total: É o montante total em
    dinheiro incorporado ao patrimônio do município.
  </span>
  <div class="h-48">
    <Series {grid} {xAxis} {yAxis} {series} />
  </div>
</Widget>
