import { Component } from "@angular/core";
import { Pokemon } from "../models/pokemon.model";

@Component({
    selector: 'app-pokemon-list',
    templateUrl: './pokemon-list.component.html',
    styleUrls: ['./pokemon-list.component.css']
})
export class PokemonListComponent {
    title:string = "List of Pokemon";
    src1:string = "https://upload.wikimedia.org/wikipedia/en/3/35/Robert_Roberts_1905%E2%80%931974.jpg";
    isVisible:boolean = true;

    listOfPokemon:Pokemon[] = 
    [{
        id:132,
        base_experience:101,
        name:"Ditto",
        sprites: {
            front_default:"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png"
        }
    },
    {
        id:25,
        base_experience:112,
        name:"Pikachu",
        sprites: {
            front_default:"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png"
        }
    }];

    changeTitle(){
        this.title = "Title has been changed!";
        this.src1 = "https://upload.wikimedia.org/wikipedia/commons/3/37/Corner_shop_-_geograph.org.uk_-_1100551.jpg";
        this.listOfPokemon.push({base_experience:64, id:1, name:"Bulbasaur", sprites:{front_default:"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png"}});
    }

    changeVisible(){
        this.isVisible = !this.isVisible;
    }
}