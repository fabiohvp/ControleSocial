function Serie(name, type) {
  this.name = name;
  this.type = type;
  this.yAxisIndex = 1; //??
  this.data = [];
}

function XAxis(data = []) {
  this.type = "category";
  this.data = data;
  this.axisPointer = {
    type: "shadow"
  };
}

function YAxis(name) {
  this.type = "value";
  this.name = name;
  this.min = null;
  this.max = null;
  this.interval = null;
  this.axisLabel = {
    formatter: "R$ {value}"
  };
}

export { Serie, XAxis, YAxis };
