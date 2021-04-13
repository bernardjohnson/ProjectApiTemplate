import { Component, OnInit } from '@angular/core';
import { EventoService } from '../service/evento.service';
import { EventoList } from 'src/app/models/eventoList';

@Component({
  selector: 'app-evento-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css']
})



export class ListarComponent implements OnInit {

  public dataSource: EventoList[];
  private isLoadingResults: boolean;
  
  constructor(private _api: EventoService) { }

  ngOnInit() {
    setInterval(() => this.getEventos(), 1000);
  }
  getEventos() {
    this._api.getEventos()
    .subscribe(res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }, err => {
      console.log(err);
      this.isLoadingResults = false;
    });
  }

}
