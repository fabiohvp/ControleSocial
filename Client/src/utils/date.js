//https://github.com/JDMcKinstry/JavaScriptDateFormat

export const mesesAbreviados = [
  "Jan",
  "Fev",
  "Mar",
  "Abr",
  "Mai",
  "Jun",
  "Jul",
  "Ago",
  "Set",
  "Out",
  "Nov",
  "Dez"
];
mesesAbreviados[NaN] = "";
mesesAbreviados[undefined] = "";

export const meses = [
  "Janeiro",
  "Fevereiro",
  "Março",
  "Abril",
  "Maio",
  "Junho",
  "Julho",
  "Agosto",
  "Setembro",
  "Outubro",
  "Novembro",
  "Dezembro"
];
meses[NaN] = "";
meses[undefined] = "";

export const dias = [
  "Domingo",
  "Segunda-feira",
  "Terça-feira",
  "Quarta-feira",
  "Quinta-feira",
  "Sexta-feira",
  "Sábado"
];
dias[NaN] = "";
dias[undefined] = "";

export default function dateFormat(dt, str, showFormatted) {
  function addHours(d, v) {
    d.setHours(d.getHours() + parseFloat(v));
    return d;
  }
  function getDayName(d, sf) {
    return sf ? dias[d.getDay()].substr(0, 3) : dias[d.getDay()];
  }
  function getWeek(d) {
    let a = new Date(d.getFullYear(), 0, 1);
    return Math.ceil(((d - a) / 864e5 + a.getDay() + 1) / 7);
  }
  function getMonthName(d, shortForm) {
    return shortForm ? meses[d.getMonth()].substr(0, 3) : meses[d.getMonth()];
  }
  let formats = {
      /*	DAY	*/
      d: function() {
        let a = this.getDate();
        return a > 9 ? a : "0" + a;
      },
      D: function() {
        return getDayName(this, true);
      },
      j: function() {
        return this.getDate();
      },
      l: function() {
        return getDayName(this);
      },
      N: function() {
        return this.getDay() + 1;
      },
      S: function() {
        return "º";
        // let a = this.getDate();
        // return /^1[0-9]$/.test(a)
        //   ? "º"
        //   : /1$/.test(a)
        //   ? "st"
        //   : /2$/.test(a)
        //   ? "nd"
        //   : /3$/.test(a)
        //   ? "rd"
        //   : "th";
      },
      w: function() {
        return this.getDay();
      },
      z: function() {
        return Math.round(
          Math.abs(
            (this.getTime() - new Date("1/1/" + this.getFullYear()).getTime()) /
              8.64e7
          )
        );
      },
      /*	WEEK	*/
      W: function() {
        return getWeek(this);
      },
      /*	MONTH	*/
      F: function() {
        return getMonthName(this);
      },
      m: function() {
        let a = this.getMonth() + 1;
        return a > 9 ? a : "0" + a;
      },
      M: function() {
        return getMonthName(this, true);
      },
      n: function() {
        return this.getMonth() + 1;
      },
      t: function() {
        return new Date(this.getFullYear(), this.getMonth() + 1, 0).getDate();
      },
      /*	YEAR	*/
      L: function() {
        let a = this.getFullYear();
        return (0 == a % 4 && 0 != a % 100) || 0 == a % 400;
      },
      o: function() {
        return parseInt(this.getFullYear());
      }, //	todo: base on week's parent year
      Y: function() {
        return parseInt(this.getFullYear());
      },
      y: function() {
        return parseInt((this.getFullYear() + "").substr(-2));
      },
      /*	TIME	*/
      a: function() {
        return this.getHours() >= 12 ? "pm" : "am";
      },
      A: function() {
        return this.getHours() >= 12 ? "PM" : "AM";
      },
      B: function() {
        return (
          "@" +
          (
            "00" +
            Math.floor(
              ((((this.getHours() + 1) % 24) * 60 + this.getMinutes()) * 60 +
                this.getSeconds() +
                this.getMilliseconds() * 0.001) /
                86.4
            )
          ).slice(-3)
        );
      },
      g: function() {
        let a = this.getHours();
        return a == 0 ? 12 : a <= 12 ? a : a - 12;
      }, //	12-hour format of an hour without leading zeros
      G: function() {
        return this.getHours();
      }, //	24-hour format of an hour without leading zeros
      h: function() {
        let a = this.getHours();
        a = a <= 12 ? a : a - 12;
        return a == 0 ? 12 : a > 9 ? a : "0" + a;
      }, //		12-hour format of an hour with leading zeros
      H: function() {
        let a = this.getHours();
        return a > 9 ? a : "0" + a;
      }, //		24-hour format of an hour with leading zeros
      i: function() {
        let a = this.getMinutes();
        return a > 9 ? a : "0" + a;
      }, //	Minutes with leading zeros
      s: function() {
        let a = this.getSeconds();
        return a > 9 ? a : "0" + a;
      }, //	Seconds, with leading zeros
      u: function() {
        return this.getMilliseconds();
      }, //	this is NOT microseconds ... it's JS :P,
      /*	TIMEZONE	*/
      e: function() {
        let a = this.toString().match(/ ([A-Z]{3,4})([-|+]?\d{4})/);
        return a.length > 1 ? a[1] : "";
      },
      I: function() {
        let a = new Date(this.getFullYear(), 0, 1),
          b = new Date(this.getFullYear(), 6, 1),
          c = Math.max(a.getTimezoneOffset(), b.getTimezoneOffset());
        return this.getTimezoneOffset() < c ? 1 : 0;
      },
      O: function() {
        let a = this.toString().match(/ ([A-Z]{3,4})([-|+]?\d{4})/);
        return a.length > 2 ? a[2] : "";
      },
      P: function() {
        let a = this.toString().match(/ ([A-Z]{3,4})([-|+]?\d{4})/);
        return a.length > 2 ? a[2].substr(0, 3) + ":" + a[2].substr(3, 2) : "";
      },
      T: function() {
        return this.toLocaleString("en", { timeZoneName: "short" })
          .split(" ")
          .pop();
      }, //	may not be reliable on Apple Systems	//	NOTE: Apple Sux
      Z: function() {
        return this.getTimezoneOffset() * 60;
      },
      /*	FULL DATE/TIME	*/
      c: function() {
        return addHours(
          new Date(this),
          -(this.getTimezoneOffset() / 60)
        ).toISOString();
      },
      r: function() {
        return addHours(
          new Date(this),
          -(this.getTimezoneOffset() / 60)
        ).toISOString();
      },
      U: function() {
        return (this.getTime() / 1000) | 0;
      }
    },
    compound = {
      commonLogFormat: "d/M/Y:G:i:s",
      exif: "Y:m:d G:i:s",
      isoYearWeek: "Y\\WW",
      isoYearWeek2: "Y-\\WW",
      isoYearWeekDay: "Y\\WWj",
      isoYearWeekDay2: "Y-\\WW-j",
      mySQL: "Y-m-d h:i:s",
      postgreSQL: "Y.z",
      postgreSQL2: "Yz",
      soap: "Y-m-d\\TH:i:s.u",
      soap2: "Y-m-d\\TH:i:s.uP",
      unixTimestamp: "@U",
      xmlrpc: "Ymd\\TG:i:s",
      xmlrpcCompact: "Ymd\\tGis",
      wddx: "Y-n-j\\TG:i:s"
    },
    constants = {
      AMERICAN: "F j, Y",
      AMERICANSHORT: "m/d/Y",
      AMERICANSHORTWTIME: "m/d/Y h:i:sA",
      ATOM: "Y-m-d\\TH:i:sP",
      COOKIE: "l, d-M-Y H:i:s T",
      EUROPEAN: "j F Y",
      EUROPEANSHORT: "d.m.Y",
      EUROPEANSHORTWTIME: "d.m.Y H:i:s",
      ISO8601: "Y-m-d\\TH:i:sO",
      LEGAL: "j F Y",
      RFC822: "D, d M y H:i:s O",
      RFC850: "l, d-M-y H:i:s T",
      RFC1036: "D, d M y H:i:s O",
      RFC1123: "D, d M Y H:i:s O",
      RFC2822: "D, d M Y H:i:s O",
      RFC3339: "Y-m-d\\TH:i:sP",
      RSS: "D, d M Y H:i:s O",
      W3C: "Y-m-d\\TH:i:sP"
    },
    pretty = {
      "pretty-a": "g:i.sA l jS \\o\\f F, Y",
      "pretty-b": "g:iA l jS \\o\\f F, Y",
      "pretty-c": "n/d/Y g:iA",
      "pretty-d": "n/d/Y",
      "pretty-e": "F jS - g:ia",
      "pretty-f": "g:iA",
      "pretty-g": "F jS, Y",
      "pretty-h": "F jS, Y g:mA"
    },
    br = {
      extenso: function() {
        return (
          formats["d"].apply(this) +
          " de " +
          getMonthName(this).toLocaleLowerCase() +
          " de " +
          this.getFullYear()
        );
      }
      //   'dd/mm/yyyy': function() {
      // 	return formats["d"].apply(this) + '/' + formats["d"].apply(this) + '/' + formats["d"].apply(this);
      //   }
    };

  if (str) {
    if (br[str]) {
      return br[str].apply(dt);
    }
    if (str == "compound") {
      if (showFormatted === false) return compound;
      let r = {};
      for (let x in compound) r[x] = dateFormat(dt, compound[x]);
      return r;
    } else if (compound[str]) {
      return dateFormat(dt, compound[str], showFormatted);
    }

    if (str == "constants") {
      if (showFormatted === false) return constants;
      let r = {};
      for (let x in constants) r[x] = dateFormat(dt, constants[x]);
      return r;
    } else if (constants[str]) {
      return dateFormat(dt, constants[str], showFormatted);
    }

    if (str == "pretty") {
      if (showFormatted === false) return pretty;
      let r = {};
      for (let x in pretty) r[x] = dateFormat(dt, pretty[x]);
      return r;
    } else if (pretty[str]) {
      return dateFormat(dt, pretty[str], showFormatted);
    }

    let ret = str.split(""),
      lc = "";

    for (let x in ret) {
      let c = ret[x];
      if (c && /[a-z]/i.test(c) && !/\\/.test(lc + c)) {
        let rx = new RegExp(c, "g");
        ret[x] = formats[c] ? formats[c].apply(dt) : c;
      }
      lc = ret[x];
    }
    return ret.join("").replace(/\\/g, "");
  }
  return dt;
}
