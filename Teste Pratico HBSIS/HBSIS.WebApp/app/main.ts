import { bootstrap }    from '@angular/platform-browser-dynamic';
import { AppComponent } from './app.component';
import { APP_ROUTER_PROVIDERS } from './app-routes';
import { HTTP_PROVIDERS } from '@angular/http';
import { HttpUtilService } from './services/http-util-service';

bootstrap(AppComponent, [
	APP_ROUTER_PROVIDERS,
	HTTP_PROVIDERS,
	HttpUtilService
])
.catch(err => console.error(err));