export class UsuarioModel {
    public id_Usuario: number;
    public nome: string;
    public documento: string;
    public telefone: string;
}

export class Usuario extends UsuarioModel {
    constructor() {
        super();
        this.id_Usuario = 0;
        this.nome = '';
        this.documento = '';
        this.telefone = '';
    }
}