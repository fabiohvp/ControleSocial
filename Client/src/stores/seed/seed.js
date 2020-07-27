export function list() {
	return [
		{
			id: "list",
			run: "Seed.List",
			args: []
		}
	];
}

export function seed(files) {
	const formData = new FormData();

	for (let i = 0; i < files.length; i++) {
		formData.append("args[]", files[i]);
	}
	formData.append("id", "seed");
	formData.append("run", "Seed.Seed");

	return formData;
}
