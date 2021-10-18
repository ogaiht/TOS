export class Uuid {

    public static readonly EMPTY: Uuid = new Uuid('00000000-0000-0000-0000-00000000000');

    constructor(private readonly value: string) { }

    static newUuid(): Uuid {
        const id: string = Uuid.createNewUuid();
        return new Uuid(id);
    }

    static fromString(value: string): Uuid {
        return new Uuid(value);
    }

    toString(): string {
        return this.value;
    }

    equal(uUId: Uuid): boolean {
        return uUId.value === this.value;
    }

    private static createNewUuid(): string {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
         });
    }
}