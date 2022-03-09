import { Component } from "@angular/core";
import { Pokemon } from "../models/pokemon.model";
import { PokeService } from "../services/poke.service";

@Component({
    selector: 'app-pokemon-list',
    templateUrl: './pokemon-list.component.html',
    styleUrls: ['./pokemon-list.component.css']
})
export class PokemonListComponent {
    title:string = "List of Pokemon";
    src1:string = "https://upload.wikimedia.org/wikipedia/en/3/35/Robert_Roberts_1905%E2%80%931974.jpg";
    isVisible:boolean = true;
    isRatingVisible:boolean = false;

    filteredName:string = "";

    listOfPokemon:Pokemon[];
    filteredListOfPoke:Pokemon[];

    constructor(private readonly pokeServ: PokeService){

        this.listOfPokemon = [];
        this.filteredListOfPoke = [];

        //getAllPokemon() methods gives an observable that has a subscrebe method to start the http requestand then handle x amount of responses
        this.pokeServ.getAllPokemon("").subscribe(result => {
            //The result of a response is then stored in our listOfPokemon property
            // console.log(result);
            result.forEach(poke => poke.rating = this.getRandomInt(5)); //Adds rating to pokemon since Db doesn't have it
            this.listOfPokemon = result;
            this.filteredListOfPoke = result;
        });
    }

    getRandomInt(max:number){
        return Math.floor(Math.random() * max);
    }

    changeTitle(){
        this.title = "Title has been changed!";
        this.src1 = "https://upload.wikimedia.org/wikipedia/commons/3/37/Corner_shop_-_geograph.org.uk_-_1100551.jpg";
        // this.listOfPokemon.push({level:64, pokeId:1, name:"Bulbasaur"});
    }

    changeVisible(){
        this.isVisible = !this.isVisible;
    }

    // public get FilteredName() : string {
    //     return this.filteredName;
    // }

    public set FilteredName(s1:string) {
        this.filteredName = s1;

        /*
            If input box for the search card is empty then it will be false
            If it is not empty, it will be true so perform the filter method
        */
        this.filteredListOfPoke = this.filteredName ? this.performFilter(this.filteredName) : this.listOfPokemon;
    }
    
    /*
        This filter will give a filtered array of Pokemon based on what the user gave
        filter based on name
        It will not care about case-sensitive
    */
    performFilter(filter:string):Pokemon[] {
        filter = filter.toLowerCase();

        let tempListOfPoke:Pokemon[];

        /*
            - filter method from the array object will return a new array based on some condition I set
            "Hello".indexOf("el") == 1
            "Hello".indexOf("ajowevoewvow") == -1 
        */
        tempListOfPoke = this.listOfPokemon.filter((pokemon:Pokemon) => pokemon.name.toLowerCase().indexOf(filter) != -1);
        
        return tempListOfPoke;
    }

    starEventWasTriggerd(num1:number){
        console.log(num1);
        this.isRatingVisible = !this.isRatingVisible;
    }
}