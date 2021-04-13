import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { EventoList } from 'src/app/models/EventoList';
import { EventoInput } from 'src/app/models/EventoInput';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = 'https://localhost:44355/api/eventos';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  getEventos(): Observable<EventoList[]> {
    return this.http.get<EventoList[]>(apiUrl + "/relatorio")
      .pipe(
        catchError(this.handleError('getEventos', []))
      );
  }


  addEvento(evento: EventoInput): Observable<EventoInput> {
    evento.tag = evento.pais + '.' + evento.regiao + '.' + evento.sensor;
    evento.timeSpan = Math.round(new Date().getTime()/1000);
    
    return this.http.post<EventoInput>(apiUrl, JSON.stringify(evento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      )
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      return of(result as T);
    };
  }
}
