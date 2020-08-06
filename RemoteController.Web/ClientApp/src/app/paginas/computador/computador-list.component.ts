import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Computador } from '../../modelos/computador';
import { ComputadorService } from '../../servicos/computador.service';
import { Modal } from '../../componentes/modal/modal.component';
import { LogService } from '../../servicos/log.service';
import { Log } from '../../modelos/log';

@Component({
    selector: 'app-computador-list',
    templateUrl: './computador-list.component.html',
    styleUrls: ['./computador-list.component.css']
})

export class ComputadorListComponent implements OnInit {
    public computadores: Computador[];
    public logs: Log[];
    public _modal = null;
    public _modalLog = null;
    public _modalTerminal = null;
    public _modalTerminalMult = null;
    public possuiLog = false;

    @ViewChild(Modal, { static: false }) modal: Modal;

    constructor(
        private computadorService: ComputadorService,
        private logService: LogService) { }

    ngOnInit() {
        this.computadorService.getComputadorList().subscribe(res => {
            this.computadores = res;
        });
    }

    bindModal(modal) {
        if (modal.title === 'LOG') this._modalLog = modal;
        else if (modal.title === 'TERMINAL') this._modalTerminal = modal;
        else this._modalTerminalMult = modal;
    }

    open(computador: Computador) {
        this.logService.getLogList(computador.id).subscribe(res => {
            this._modalLog.open();
            this.logs = res;
            this.possuiLog = this.logs.length === 0 ? false : true; 
        });
    }

    close() {
        this._modalLog.close();
    }

    openTerminal(computador: Computador) {
        this.logService.getLogList(computador.id).subscribe(res => {
            debugger
            this._modalTerminal.open();
            this.logs = res;
            this.possuiLog = this.logs.length === 0 ? false : true; 
        });
    }

    closeTerminal() {
        this._modalTerminal.close();
    }

    openTerminalMult(computador: Computador) {
        this._modalTerminalMult.open();
    }

    closeTerminalMult() {
        this._modalTerminalMult.close();
    }
}
