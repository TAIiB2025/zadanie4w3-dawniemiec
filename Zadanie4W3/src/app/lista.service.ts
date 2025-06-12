import { Injectable } from '@angular/core';
import { Film } from '../models/film';
import { Observable, of } from 'rxjs';
import { FilmBody } from '../models/film-body';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ListaService {
//   private static idGen = 1;

//   private lista: Film[] = [
//   { id: ListaService.idGen++, tytul: "Incepcja", rezyser: "Christopher Nolan", gatunek: "Sci-Fi", rok_wydania: 2010 },
//   { id: ListaService.idGen++, tytul: "Parasite", rezyser: "Bong Joon-ho", gatunek: "Dramat", rok_wydania: 2019 },
//   { id: ListaService.idGen++, tytul: "Skazani na Shawshank", rezyser: "Frank Darabont", gatunek: "Dramat", rok_wydania: 1994 },
//   { id: ListaService.idGen++, tytul: "Matrix", rezyser: "Lana i Lilly Wachowski", gatunek: "Sci-Fi", rok_wydania: 1999 },
//   { id: ListaService.idGen++, tytul: "Gladiator", rezyser: "Ridley Scott", gatunek: "Historyczny", rok_wydania: 2000 }
// ];

  private readonly baseApiURL = 'http://localhost:5010/api/Filmy';
  constructor(private httpClient: HttpClient) {}

  get(): Observable<Film[]> {
    //return of(this.lista);
    return this.httpClient.get<Film[]>(this.baseApiURL);
  }

  getByID(id: number): Observable<Film> {
    // const ksiazka = this.lista.find(k => k.id === id);
    // if(ksiazka == null) {
    //   throw new Error('Nie znaleziono wskazanej książki');
    // }
    // return of(ksiazka);
    const url = `${this.baseApiURL}/${id}`;
    return this.httpClient.get<Film>(url);

  }

  delete(id: number): Observable<void> {
    // this.lista = this.lista.filter(k => k.id !== id);
    // return of(undefined);
    const url = `${this.baseApiURL}/${id}`;
    return this.httpClient.delete<void>(url);
  }

  put(id: number, body: FilmBody): Observable<void> {
    // const ksiazka = this.lista.find(k => k.id === id);
    // if(ksiazka == null) {
    //   throw new Error('Nie znaleziono wskazanej książki');
    // }

    // ksiazka.rezyser = body.rezyser;
    // ksiazka.gatunek = body.gatunek;
    // ksiazka.rok_wydania = body.rok_wydania;
    // ksiazka.tytul = body.tytul;

    // return of(undefined);
    const url = `${this.baseApiURL}/${id}`;
    return this.httpClient.put<void>(url,body);
  }

  post(body: FilmBody): Observable<void> {
    // const ksiazka: Film = {
    //   id: ListaService.idGen++,
    //   rezyser: body.rezyser,
    //   gatunek: body.gatunek,
    //   rok_wydania: body.rok_wydania,
    //   tytul: body.tytul
    // };

    // this.lista.push(ksiazka);

    // return of(undefined);
    return this.httpClient.post<void>(this.baseApiURL, body);
  }
}
