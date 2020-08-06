import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './componentes/nav-menu/nav-menu.component';
import { ComputadorListComponent } from './paginas/computador/computador-list.component';
import { ComputadorService } from './servicos/computador.service';
import { Modal } from './componentes/modal/modal.component';
import { LogService } from './servicos/log.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        ComputadorListComponent,
        Modal
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: ComputadorListComponent, pathMatch: 'full' }
        ])
    ],
    providers: [
        ComputadorService,
        LogService
    ],
    bootstrap: [AppComponent],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA,
        NO_ERRORS_SCHEMA
    ]
})

export class AppModule { }
