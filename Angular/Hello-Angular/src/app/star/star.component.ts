import { Component, Input, OnChanges, OnDestroy, OnInit, Output, EventEmitter} from '@angular/core';
import { faStar } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.css']
})
export class StarComponent implements OnInit, OnChanges, OnDestroy {
  @Input()rating:number = 0;

  starWidth:number = 0;
  faStar = faStar;

  @Output() ratingEmitter = new EventEmitter<number>();

  constructor() { }

  //Call on this function whenever the component is destroyed
  ngOnDestroy(): void {
  }

  //Call on this function whenever datab binding is finish
  ngOnChanges(): void {
    this.starWidth = this.rating*90/5;
  }
  
  ngOnInit(): void {
  }

  onStarClicked(): void {
    this.ratingEmitter.emit(this.rating);
  }
}
