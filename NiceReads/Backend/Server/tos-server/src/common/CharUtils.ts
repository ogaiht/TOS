export class CharUtils {

    public static readonly A: number = 65;
    public static readonly Z: number = 90;
    public static readonly a: number = 97;
    public static readonly z: number = 122;
    public static readonly ZERO: number = 48;
    public static readonly NINE: number = 57;

    public static isLowerCase(charCode: number): boolean {
        return charCode >= CharUtils.a && charCode <= CharUtils.z;
    }

    public static isUpperCase(charCode: number): boolean {
        return charCode >= CharUtils.A && charCode <= CharUtils.Z;
    }

    public static isNumeric(charCode: number): boolean {
        return charCode >= CharUtils.ZERO && charCode <= CharUtils.NINE
    }
}