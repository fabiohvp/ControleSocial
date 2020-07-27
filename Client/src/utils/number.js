export function format2Decimals(value) {
	if (!value) {
		return (0.0).toFixed(2);
	}
	return value.toFixed(2);
}

export function format(value) {
	if (value) {
		return value.toLocaleString('pt-br', { minimumFractionDigits: 2 });
	}
	return "";
}