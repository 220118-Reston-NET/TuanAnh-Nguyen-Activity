import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pokemon } from '../models/pokemon.model';
import { PokeService } from '../services/poke.service';

@Component({
  selector: 'app-add-poke',
  templateUrl: './add-poke.component.html',
  styleUrls: ['./add-poke.component.css']
})
export class AddPokeComponent implements OnInit {

  pokeGroup = new FormGroup({
    name: new FormControl(""),
    attack: new FormControl(0),
    defense: new FormControl(0),
    health: new FormControl(0),
    speed: new FormControl(0),
    type: new FormControl("")
  });

  constructor(private readonly pokeServ:PokeService) {

  }

  ngOnInit(): void {
  }

  addPokemon(p_pokeGroup:FormGroup){
    let pokemon:Pokemon = {
      name : p_pokeGroup.get("name")?.value,
      attack : p_pokeGroup.get("attack")?.value,
      defense : p_pokeGroup.get("defense")?.value,
      health : p_pokeGroup.get("health")?.value,
      speed : p_pokeGroup.get("speed")?.value,
      type : p_pokeGroup.get("type")?.value,

      level:1,
      pokeId:1,
      rating:5
    }
    this.pokeServ.addPokemon(pokemon).subscribe();
    // console.log(pokemon);
  }

}
