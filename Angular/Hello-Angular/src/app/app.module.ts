import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { PokemonListComponent } from './pokemon-list/pokemon-list.component';
import { TestComponent } from './test/test.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PokeProfileComponent } from './poke-profile/poke-profile.component';
import { RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { StarComponent } from './star/star.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AddPokeComponent } from './add-poke/add-poke.component';

@NgModule({
  declarations: [ //This will hold our references to our components
    AppComponent,
    PokemonListComponent,
    TestComponent,
    NavBarComponent,
    PokeProfileComponent,
    StarComponent,
    AddPokeComponent
  ],
  imports: [ //This will hold our references to modules inside our node_module folder
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: "pokeList", component: PokemonListComponent},
      {path: "profile/:pokename", component: PokeProfileComponent},
      {path: "pokemon", component: AddPokeComponent},
      {path: "", component: PokemonListComponent}, //Default component you want to show
      {path: "**", component: NotFoundComponent} //Wildcard for any endpoint that doesn't exist
    ]),
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
