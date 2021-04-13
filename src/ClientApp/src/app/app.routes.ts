import {Routes} from '@angular/router';
import { HomeComponent } from './navegacao/home/home.component';
import { AdicionarComponent } from './evento/adicionar/adicionar.component';
import { ListarComponent } from './evento/listar/listar.component';

export const rootRouterConfig: Routes = [
    {path: 'home', component: HomeComponent},
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'evento-adicionar', component: AdicionarComponent},
    {path: 'evento-listar', component: ListarComponent}

];