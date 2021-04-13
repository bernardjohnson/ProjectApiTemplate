import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { APP_BASE_HREF } from '@angular/Common';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AdicionarComponent } from './evento/adicionar/adicionar.component';
import { ListarComponent } from './evento/listar/listar.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { FooterComponent } from './navegacao/footer/footer.component';
import { HomeComponent } from './navegacao/home/home.component';
import { rootRouterConfig } from './app.routes';
import {EventoService}from './evento/service/evento.service';


@NgModule({
  declarations: [
    AppComponent,
    AdicionarComponent,
    ListarComponent,
    MenuComponent,
    FooterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    [RouterModule.forRoot(rootRouterConfig)],
    ReactiveFormsModule
  ],
  providers: [
    {provide: APP_BASE_HREF, useValue: '/'},
    EventoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
