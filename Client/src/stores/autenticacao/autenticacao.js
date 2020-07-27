export function signIn(email, senha) {
	return {
		id: "signIn",
		run: "Autenticacao.SignIn",
		args: [email, senha]
	};
}

export function signOut() {
	return {
		id: "signOut",
		run: "Autenticacao.SignOut",
		args: []
	};
}