import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickGameComponent } from './quick-game.component';

describe('QuickGameComponent', () => {
  let component: QuickGameComponent;
  let fixture: ComponentFixture<QuickGameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickGameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
