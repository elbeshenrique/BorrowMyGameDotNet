import { ClassConstructor, plainToClass } from "class-transformer";

export default class JsonUtils {

    public static plainToClassArray<T>(classConstructor: ClassConstructor<T>, array: any[]): T[] {
        const objectArray: T[] = new Array<T>();
        for (const item of array) {
            const object: T = plainToClass(classConstructor, item);
            objectArray.push(object);
        }

        return objectArray;
    }

}