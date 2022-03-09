import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPokeComponent } from './add-poke.component';

describe('AddPokeComponent', () => {
  let component: AddPokeComponent;
  let fixture: ComponentFixture<AddPokeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPokeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPokeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
