<script>
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import { getHorizontalMarkLine } from "../../../../../../../components/Chart/Chart.svelte";
  import Series from "../../../../../../../components/Chart/Series.svelte";
  import "echarts/lib/component/markLine";

  export let model;

  const options = {
    legend: {
      show: false
    }
  };
  const yAxis = { show: false };

  let xAxis;
  let series;

  $: render(model);

  function render(model) {
    if (!model) {
      return;
    }
    const anos = [];
    const values = [];

    model.value.forEach(o => {
      anos.push(o.ano);
      values.push(o.limiteConstitucional);
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
        xAxisIndex: 0,
        yAxisIndex: 0,
        //name: "Aplicação em educação",
        data: values,
        markLine: getHorizontalMarkLine(15, "Limite de 15%")
      }
    ];
  }
</script>

<Widget>
  <span slot="title">
    Evolução do limite constitucional mínimo aplicado em educação
  </span>
  <span slot="tooltip">
    Evolução, em percentuais, dos recursos aplicados em educação nos últimos
    exercícios.
  </span>
  <div class="h-48">
    <Series {xAxis} {yAxis} {series} {options} />
  </div>
</Widget>
