import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";

@Injectable({
    providedIn: 'root'
})
export class SnackBarService {
    private defaultDuration = 3000;

    constructor(
        public _snackBar: MatSnackBar
    ) { }

    showSuccess(message: string, duration?: number) {
        this._snackBar.open(message, 'Aceptar', {
            duration: duration ?? this.defaultDuration,
            panelClass: ['snackbar-success']
        })
    }

    showError(message: string, duration?: number) {
        this._snackBar.open(message, 'Aceptar', {
            duration: duration ?? this.defaultDuration,
            panelClass: ['snackbar-error']
        })
    }

    showInfo(message: string, duration?: number) {
        this._snackBar.open(message, 'Aceptar', {
            duration: duration ?? this.defaultDuration,
            panelClass: ['snackbar-info']
        })
    }

    showWarning(message: string, duration?: number) {
        this._snackBar.open(message, 'Aceptar', {
            duration: duration ?? this.defaultDuration,
            panelClass: ['snackbar-warning']
        })
    }
}