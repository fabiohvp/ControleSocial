const settings = {
	municipios: {
		get: value => {
			const data = [
				{ value: "001", label: "Afonso Cláudio" },
				{ value: "002", label: "Água Doce do Norte" },
				{ value: "003", label: "Águia Branca" },
				{ value: "004", label: "Alegre" },
				{ value: "005", label: "Alfredo Chaves" },
				{ value: "006", label: "Alto Rio Novo" },
				{ value: "007", label: "Anchieta" },
				{ value: "008", label: "Apiacá" },
				{ value: "009", label: "Aracruz" },
				{ value: "010", label: "Atílio Vivácqua" },
				{ value: "011", label: "Baixo Guandu" },
				{ value: "012", label: "Barra de São Francisco" },
				{ value: "013", label: "Boa Esperança" },
				{ value: "014", label: "Bom Jesus do Norte" },
				{ value: "015", label: "Brejetuba" },
				{ value: "016", label: "Cachoeiro de Itapemirim" },
				{ value: "017", label: "Cariacica" },
				{ value: "018", label: "Castelo" },
				{ value: "019", label: "Colatina" },
				{ value: "020", label: "Conceição da Barra" },
				{ value: "021", label: "Conceição do Castelo" },
				{ value: "501", label: "Consórcio do Estado do Espírito Santo" },
				{ value: "022", label: "Divino de São Lourenço" },
				{ value: "023", label: "Domingos Martins" },
				{ value: "024", label: "Dores do Rio Preto" },
				{ value: "025", label: "Ecoporanga" },
				{ value: "026", label: "Fundão" },
				{ value: "078", label: "Governador Lindenberg" },
				{ value: "027", label: "Guaçuí" },
				{ value: "028", label: "Guarapari" },
				{ value: "029", label: "Ibatiba" },
				{ value: "030", label: "Ibiraçu" },
				{ value: "031", label: "Ibitirama" },
				{ value: "032", label: "Iconha" },
				{ value: "033", label: "Irupi" },
				{ value: "034", label: "Itaguaçu" },
				{ value: "035", label: "Itapemirim" },
				{ value: "036", label: "Itarana" },
				{ value: "037", label: "Iúna" },
				{ value: "038", label: "Jaguaré" },
				{ value: "039", label: "Jerônimo Monteiro" },
				{ value: "040", label: "João Neiva" },
				{ value: "041", label: "Laranja da Terra" },
				{ value: "042", label: "Linhares" },
				{ value: "043", label: "Mantenópolis" },
				{ value: "044", label: "Marataízes" },
				{ value: "045", label: "Marechal Floriano" },
				{ value: "046", label: "Marilândia" },
				{ value: "047", label: "Mimoso do Sul" },
				{ value: "048", label: "Montanha" },
				{ value: "049", label: "Mucurici" },
				{ value: "050", label: "Muniz Freire" },
				{ value: "051", label: "Muqui" },
				{ value: "052", label: "Nova Venécia" },
				{ value: "053", label: "Pancas" },
				{ value: "054", label: "Pedro Canário" },
				{ value: "055", label: "Pinheiros" },
				{ value: "056", label: "Piúma" },
				{ value: "057", label: "Ponto Belo" },
				{ value: "058", label: "Presidente Kennedy" },
				{ value: "059", label: "Rio Bananal" },
				{ value: "060", label: "Rio Novo do Sul" },
				{ value: "061", label: "Santa Leopoldina" },
				{ value: "062", label: "Santa Maria de Jetibá" },
				{ value: "063", label: "Santa Teresa" },
				{ value: "064", label: "São Domingos do Norte" },
				{ value: "065", label: "São Gabriel da Palha" },
				{ value: "066", label: "São José do Calçado" },
				{ value: "067", label: "São Mateus" },
				{ value: "068", label: "São Roque do Canaã" },
				{ value: "069", label: "Serra" },
				{ value: "070", label: "Sooretama" },
				{ value: "071", label: "Vargem Alta" },
				{ value: "072", label: "Venda Nova do Imigrante" },
				{ value: "073", label: "Viana" },
				{ value: "074", label: "Vila Pavão" },
				{ value: "075", label: "Vila Valério" },
				{ value: "076", label: "Vila Velha" },
				{ value: "077", label: "Vitória" }
			];

			select(data, value);
			return data;
		}
	},
	ano: { get: segment => { } },
	anos: {
		get: (value, segment) => {
			let data = [];

			if (segment === "iegm") {
				data = [
					{ label: "2017", value: 2017 },
					{ label: "2016", value: 2016 },
					{ label: "2015", value: 2015 }
				];
			} else {
				data = [
					{ label: "2020", value: 2020 },
					{ label: "2019", value: 2019 },
					{ label: "2018", value: 2018 },
					{ label: "2017", value: 2017 },
					// { label: "2016", value: 2016 },
					// { label: "2015", value: 2015 },
					// { label: "2014", value: 2014 },
					// { label: "2013", value: 2013 }
				];
			}

			select(data, value);
			return data;
		}
	}
};

function select(data, value) {
	for (let i = 0; i < data.length; i++) {
		if (data[i].value === value) {
			data[i].selected = true;
		}
	}
}

export default settings;
