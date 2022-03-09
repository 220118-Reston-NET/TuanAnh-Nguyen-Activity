import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PokeApi } from '../models/pokeApi.model';
import { Pokemon } from '../models/pokemon.model';

@Injectable({
  providedIn: 'root'
})
export class PokeService {

  constructor(private readonly http:HttpClient) { }

  getAllPokemon(somevar:string) : Observable<Pokemon[]>
  {
    return this.http.get<Pokemon[]>(`https://pokedemo.azurewebsites.net/api/Pokemon/GetAll/${somevar}`);
  }

  getPokeByName(pokeName:string | null) : Observable<PokeApi> {
    let pokeNameString:string = <string>pokeName;
    pokeNameString = pokeNameString.toLowerCase();
    return this.http.get<PokeApi>(`https://pokeapi.co/api/v2/pokemon/${pokeNameString}`);
  }
}
