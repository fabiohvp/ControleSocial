<script>
  import Widget from "../../components/Widget/Widget.svelte";
  import Series from "../../components/Chart/Series.svelte";

  export let receita;
  export let despesa;

  export let view = "receita";

  const grid = {
    left: 90
  };
  let legends;
  let series;
  let xAxis;

  const yAxis = [
    {
      type: "value",
      name: "Receita",
      axisLabel: {
        formatter: "R$ {value}"
      }
    },
    {
      type: "value",
      name: "Despesa",
      axisLabel: {
        formatter: "R$ {value}"
      }
    }
  ];

  $: render(receita, despesa);

  function render(receita, despesa) {
    if (!receita || !despesa) {
      series = null;
      return;
    }

    const anos = [];
    const arrecadadas = [];
    const empenhadas = [];
    const liquidadas = [];
    const pagas = [];

    receita.value.forEach(r => {
      anos.push(r.ano);
      arrecadadas.push(r.arrecadada);
    });

    despesa.value.forEach(d => {
      empenhadas.push(d.empenhada);
      liquidadas.push(d.liquidada);
      pagas.push(d.paga);
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
        name: "Rec. arrecadada",
        data: arrecadadas
      },
      {
        type: "bar",
        name: "Desp. empenhada",
        data: empenhadas
      },
      {
        type: "bar",
        name: "Desp. liquidada",
        data: liquidadas
      },
      {
        type: "bar",
        name: "Desp. paga",
        data: pagas
      }
    ];

    let selected;

    if (view === "receita") {
      selected = {
        "Desp. empenhada": false,
        "Desp. paga": false
      };
    } else {
      selected = {
        "Rec. arrecadada": false
      };
    }

    legends = {
      data: series.map(s => s.name),
      selected
    };
  }
</script>

<Widget>
  <span slot="title">
    <slot name="title" />
  </span>
  <span slot="tooltip">
    <slot name="tooltip" />
  </span>
  <div class="h-48">
    <Series {grid} {xAxis} {yAxis} {series} {legends} />
  </div>
</Widget>
