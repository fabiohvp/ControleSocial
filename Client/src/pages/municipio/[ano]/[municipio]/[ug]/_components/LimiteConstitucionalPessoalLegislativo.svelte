<script>
  import Icon from "fa-svelte";
  import { faThumbsUp } from "@fortawesome/free-solid-svg-icons/faThumbsUp";
  import Gauge from "../../../../../../components/Chart/Gauge.svelte";
  import Widget from "../../../../../../components/Widget/Widget.svelte";

  export let limite;
  export let height = 40;

  const serie = {
    max: limite > 10 ? limite : 10,
    title: {
      show: false
    },
    splitNumber: 4,
    axisLine: {
      lineStyle: {
        width: 35,
        color: [
          [0.54, "#617e8c"],
          [0.57, "#eff170"],
          [0.6, "#f4b351"],
          [1, "#e68465"]
        ]
      }
    },
    detail: {
      formatter: function() {
        return "Limite LRF";
      },
      color: "#000",
      fontWeight: "normal",
      fontSize: 14
    },
    data: [{ name: "Limite LRF", value: limite }]
  };
</script>

<Widget>
  <span slot="title">Pessoal - Legislativo</span>
  <span slot="tooltip">
    De acordo com a LRF (Lei de Responsabilidade Fiscal) as despesas com pessoal
    do Poder Legislativo não podem ultrapassar 6% da RCL (Receita Corrente
    Líquida) do Município.
    <br />
    <br />
    Caso esses gastos atinjam 5,4% da RCL o Tribunal de Contas emitirá parecer
    de alerta.
    <br />
    <br />
    Caso esses gastos atinjam 5,7% da RCL o município entra no limite
    prudencial.
  </span>
  <div class="h-{height} text-center">
    <span class="text-3xl">
      <Icon icon={faThumbsUp} />
      {limite} %
    </span>
    <div class="h-full" style="margin-top:-.8em;">
      <Gauge {serie} />
    </div>
  </div>
</Widget>
