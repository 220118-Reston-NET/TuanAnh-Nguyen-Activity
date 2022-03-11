import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Pokemon } from '../models/pokemon.model';

import { PokeService } from './poke.service';

describe('PokeService', () => {
  let service: PokeService;
  let httpMock : HttpTestingController;

  let dummyPokeDatabase:Pokemon[] = [
    {
      pokeId: 1,
      attack: 40,
      defense: 40,
      health: 40,
      level: 1,
      name: 'Terrance',
      rating: 7.2,
      speed: 10,
      type: 'ghost'
    }
  ];

  beforeEach(() => {
    //This is similar to @NgModule and we have to sert the dependencies for this testing environment
    //Start thinking the testing environment is a completely new angular project and you have to state al\ll the depenedencies all over again
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        PokeService
      ]
    });
    service = TestBed.inject(PokeService);

    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve all pokemon data from the database', () => {
    service.getAllPokemon().subscribe((response) => {
      expect(response[0].name).toBe(dummyPokeDatabase[0].name);
    })

    //We are mocking this particular url if the service tries to communicate 
    const httpReq = httpMock.expectOne("https://pokedemo.azurewebsites.net/api/Pokemon/GetAll");
    //We are also checking that it is a get method
    expect(httpReq.request.method).toBe("GET");

    //We will guarantee on giving a http response that holds the dummyPokeDatabase
    httpReq.flush(dummyPokeDatabase);
  })

  
});
