<script>
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import Series from "../../../../../../../components/Chart/Series.svelte";

  export let model;

  const grid = {
    left: 90
  };
  let legends;
  let series;
  let xAxis;

  const yAxis = [
    {
      type: "value",
      name: "Aplicação em educação",
      axisLabel: {
        formatter: "R$ {value}"
      }
    },
    {
      type: "value",
      name: "Receita arrecadada",
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
    const aplicacao = [];
    const arrecadadas = [];

    model.value.forEach(m => {
      anos.push(m.ano);
      aplicacao.push(m.aplicacao);
      arrecadadas.push(m.arrecadada);
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
        type: "bar",
        name: "Aplicação em educação",
        data: aplicacao
      },
      {
        type: "line",
        name: "Receita arrecadada",
        data: arrecadadas
      }
    ];

    legends = {
      data: series.map(s => s.name),
      selected: {
        "Receita arrecadada": false
      }
    };
  }
</script>

<Widget>
  <span slot="title">
    Evolução da aplicação em Receita Arrecadada X Educação
  </span>
  <span slot="tooltip">
    Aplicação em educação: recursos aplicados. Receita Total: É o montante total
    em dinheiro incorporado ao patrimônio do município.
  </span>
  <div class="h-48">
    <Series {grid} {xAxis} {yAxis} {series} {legends} />
  </div>
</Widget>
