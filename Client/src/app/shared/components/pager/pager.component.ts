import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent implements OnInit {

  @Input() pageSize :number |any;
  @Input() totalCount :number |any;
  @Output() pageChanged =new EventEmitter<number>();
  


  constructor() { }

  ngOnInit(): void {
  }

onPagerChange(e: any){
  this.pageChanged.emit(e.page);
}

}