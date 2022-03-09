import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { PokeApi } from '../models/pokeApi.model';
import { PokeService } from '../services/poke.service';

@Component({
  selector: 'app-poke-profile',
  templateUrl: './poke-profile.component.html',
  styleUrls: ['./poke-profile.component.css']
})
export class PokeProfileComponent implements OnInit {
  pokeName:string | null = "No Pokemon Selected";
  pokemon:PokeApi;

  constructor(private readonly router:ActivatedRoute, 
              private readonly pokeServ:PokeService) 
  {
    this.pokemon = {
      sprites: {
        back_default: "",
        back_shiny: "",
        front_default: "",
        front_shiny: ""
      } 
    };
  }

  //Lifescycle hook in Angular
  ngOnInit(): void {
    //certain functionality before things happen
    this.pokeName = this.router.snapshot.paramMap.get("pokename");
    this.pokeServ.getPokeByName(this.pokeName).subscribe(result => {
      this.pokemon = result;
    });
  }
}
