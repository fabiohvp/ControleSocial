<script>
  import Widget from "../../components/Widget/Widget.svelte";
  import Series from "../../components/Chart/Series.svelte";

  export let remessaReceita;
  export let remessaDespesa;

  const grid = {
    left: 130,
    top: 30,
    height: "80%"
  };
  const tooltip = {
    trigger: "axis",
    axisPointer: {
      type: "shadow"
    }
  };
  let series;
  let xAxis;
  let yAxis;

  $: render(remessaReceita, remessaDespesa);

  function render(remessaReceita, remessaDespesa) {
    if (!remessaReceita || !remessaDespesa) {
      series = null;
      return;
    }

    yAxis = {
      type: "category",
      data: [
        "Receita prevista",
        "Receita arrecadada",
        "Despesa prevista",
        "Despesa empenhada",
        "Despesa liquidada",
        "Despesa paga"
      ]
    };

    xAxis = {
      type: "value",
      show: false
    };

    series = [
      {
        type: "bar",
        position: "left",
        data: [
          remessaReceita.value.previsaoInicial,
          remessaReceita.value.arrecadada,
          remessaDespesa.value.previsaoInicial,
          remessaDespesa.value.empenhada,
          remessaDespesa.value.liquidada,
          remessaDespesa.value.paga
        ]
      }
    ];
  }
</script>

<Widget>
  <span slot="title">Receitas X Despesas</span>
  <span slot="tooltip">
    Possibilita comparar os gastos realizados com o montante arrecadado no
    exercício e identificar a ocorrência de déficit (despesa maior que receita)
    ou superávit (receita maior que despesa).
  </span>
  <div class="h-48">
    <Series {grid} {xAxis} {yAxis} {series} {tooltip} />
  </div>
</Widget>
