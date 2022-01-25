export class User {
    public userID: number;
    public name: string;
    public email: string;
    public password: string;
    public dateOfBirth: Date;
    public errorMessage: string;
    public key: string;
    public constructor() {
        this.userID = 0;
        this.name = "";
        this.email = "";
        this.password = "";
        this.dateOfBirth = new Date();
        this.errorMessage = "";
        this.key = "";
    }
}