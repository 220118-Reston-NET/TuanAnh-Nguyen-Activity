import { ComponentFixture, fakeAsync, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { observable, Observable } from 'rxjs';
import { Pokemon } from '../models/pokemon.model';
import { PokeService } from '../services/poke.service';
import { PokemonListComponent } from './pokemon-list.component';

describe('PokemonListComponent', () => {
  //Component is the actual component that is made in this testing environment
  let component: PokemonListComponent;
  //Fixture mimics the lifecycle hooks of a component
  //Fixture is also the HTML dom
  let fixture: ComponentFixture<PokemonListComponent>;
  let service: PokeService;

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

  class PokeMockService {
      getAllPokemon(){ return new Observable((observable) =>  observable.next(dummyPokeDatabase))};
      getPokeByName(pokeName:string | null){};
      addPokemon(pokemon:Pokemon){};
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PokemonListComponent ],
      //Essentially I am telling Angular that anything in this cpomonent that needs PokeService, use the PokeMockService class instead
      providers: [
        {provide: PokeService, useClass: PokeMockService}
      ]
    })
    .compileComponents();

    service = TestBed.inject(PokeService);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PokemonListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Title should change to "Title has been changed!" when change the tille! button is clicked', () => {
    let headingElement: HTMLElement = fixture.debugElement.query(By.css("#heading")).nativeElement;
    let buttonElement: HTMLElement = fixture.debugElement.query(By.css("#title")).nativeElement;

    expect(headingElement.innerHTML).toBe("List of Pokemon");
    //This will emulate clicking the button
    buttonElement.click();

    //Since data has change in the TS file, a special lifescycle hooks needs to be executed to actually persisthe that change
    //So we have to manually trigger the lifecycle hook that is usually automated
    fixture.detectChanges();

    //This makes sure that all data is finalized and then go ahead and check if it worked
    fixture.whenStable().then(() => {
        expect(headingElement.innerHTML).toBe("Title has been changed!");
    });
  });
});
