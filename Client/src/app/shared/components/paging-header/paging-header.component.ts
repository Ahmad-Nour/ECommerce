import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.css']
})
export class PagingHeaderComponent implements OnInit {

  @Input() pageNumber :number |any;
  @Input() pageSize :number |any;
  @Input() totalCount :number |any;
  
  constructor() { }

  ngOnInit(): void {
  }

}
