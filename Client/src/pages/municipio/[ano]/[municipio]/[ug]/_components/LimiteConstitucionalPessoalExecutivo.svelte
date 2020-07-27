<script>
  import Icon from "fa-svelte";
  import { faThumbsUp } from "@fortawesome/free-solid-svg-icons/faThumbsUp";
  import Gauge from "../../../../../../components/Chart/Gauge.svelte";
  import Widget from "../../../../../../components/Widget/Widget.svelte";

  export let limite;
  export let height = 40;

  const serie = {
    title: {
      show: false
    },
    axisLine: {
      lineStyle: {
        width: 35,
        color: [
          [0.486, "#617e8c"],
          [0.513, "#eff170"],
          [0.54, "#f4b351"],
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
  <span slot="title">Pessoal - Executivo</span>
  <span slot="tooltip">
    De acordo com a LRF (Lei de Responsabilidade Fiscal) as despesas com pessoal
    no Poder Executivo não podem ultrapassar 54% da RCL (Receita Corrente
    Líquida) do Município.
    <br />
    <br />
    Caso esses gastos atinjam 51,3% da RCL o município entra no limite
    prudencial.
    <br />
    <br />
    Caso esses gastos atinjam 48,6% da RCL o Tribunal de Contas emitirá parecer
    de alerta.
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
