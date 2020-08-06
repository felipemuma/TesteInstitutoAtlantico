import { ComponentFixture, async, TestBed } from '@angular/core/testing';
import { ComputadorListComponent } from './computador-list.component';

describe('ComputadorListComponent', () => {
    let component: ComputadorListComponent;
    let fixture: ComponentFixture<ComputadorListComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ComputadorListComponent]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(ComputadorListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
