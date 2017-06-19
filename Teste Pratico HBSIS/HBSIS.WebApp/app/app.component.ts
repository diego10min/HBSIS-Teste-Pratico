import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import './rxjs-operators';

@Component({
  selector: 'meu-app',
  template: `
    <nav class="navbar navbar-inverse navbar-fixed-top">
			<div class="container">
				<div class="navbar-header">
						<a class="navbar-brand" href="#">HBSIS - Teste Prático</a>
				</div>
			</div>
		</nav>
    <br /><br /><br />
    <router-outlet></router-outlet>
	`,
	directives: [ ROUTER_DIRECTIVES ]
})
export class AppComponent {
}