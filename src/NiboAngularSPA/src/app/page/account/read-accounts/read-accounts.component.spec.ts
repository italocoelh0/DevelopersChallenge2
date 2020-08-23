import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadAccountsComponent } from './read-accounts.component';

describe('ReadAccountsComponent', () => {
  let component: ReadAccountsComponent;
  let fixture: ComponentFixture<ReadAccountsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReadAccountsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReadAccountsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
