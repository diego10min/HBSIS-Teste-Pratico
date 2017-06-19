import { Component, Input, Output, Injectable, OnInit, EventEmitter } from '@angular/core';
import { Usuario } from '../.././models/usuario';
import { UsuarioService } from '../.././services/usuario-service';
import { Router } from '@angular/router';

declare var jQuery:any;

@Component({
	selector: 'modal-persiste-usuario',
	templateUrl: 'app/views/usuario/usuario-modal-persiste.html',
	providers: [ UsuarioService]
})

@Injectable()
export class ModalPersisteUsuarioComponent implements OnInit {

	@Input() msgErro: string;
	@Input() usuario: Usuario;
	@Input() id: string;
	@Input() titulo: string;
	@Output() atualizaUsuarios: EventEmitter<any> = new EventEmitter();

	constructor(private router: Router, private usuarioService: UsuarioService) { }

	ngOnInit() {
		this.usuario = new Usuario();
	}

	persisteUsuario() {
		if(this.usuario.id_Usuario > 0){
			this.usuarioService.atualizar(this.usuario)
				.subscribe(
					usuarios => this.sucessoPersiste(usuarios),
                	error => this.msgErro = error);
		}else{
			this.usuarioService.cadastrar(this.usuario)
				.subscribe(
					usuarios => this.sucessoPersiste(usuarios),
                	error => this.msgErro = error);
		}
	}

	fecharModal(){
		this.msgErro = "";
		jQuery("#modalPersisteUsuario").modal("hide");
	}

	sucessoPersiste(usu: any){
		this.fecharModal();
		this.atualizaUsuarios.emit(usu);
	}

}