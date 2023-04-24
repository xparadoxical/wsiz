//zad 1
class Rectangle {
    constructor(height, width, name) {
        this.height = height;
        this.width = width;
        this.name = name;
    }

    perimeter() {
        return 2 * this.height + 2 * this.width;
    }

    area() {
        return this.height * this.width;
    }

    compareArea(rect2) {
        let area1 = this.area();
        let area2 = rect2.area();

        if (area1 == area2)
            return [this, rect2];
        return area1 > area2 ? this : rect2;
    }

    //zad 5
    static longestOf(rect1, rect2) {
        let area1 = rect1.perimeter();
        let area2 = rect2.perimeter();

        if (area1 == area2)
            return [rect1, rect2];
        return area1 > area2 ? rect1 : rect2;
    }

    //zad 6
    setName(newName) {
        this.name = newName;
    }
}

console.log("rectangle");
console.log(new Rectangle(1, 1, "square").perimeter());
console.log(new Rectangle(1, 8, "wide").area());
let rect = new Rectangle(10, 1, "tall");
rect.setName("asdfasdf");
console.log(rect.compareArea(new Rectangle(2, 2, "2x2")));
console.log(Rectangle.longestOf(new Rectangle(1, 1, "a"), new Rectangle(2, 1, "b")));


//zad 2
class Triangle {
    constructor(height, base, name) {
        this.height = height;
        this.base = base;
        this.name = name;
    }

    area() {
        return this.base * this.height / 2;
    }

    compareArea(triangle2) {
        let area1 = this.area();
        let area2 = triangle2.area();

        if (area1 == area2)
            return [this, triangle2];
        return area1 > area2 ? this : triangle2;
    }
}

console.log("triangle");
console.log(new Triangle(8, 3, "tall").area());
console.log(new Triangle(1, 5, "flat").compareArea(new Triangle(2, 2, "3rd")));


//zad 3
class Trapezoid {
    constructor(height, base1, base2, name) {
        this.height = height;
        this.base1 = base1;
        this.base2 = base2;
        this.name = name;
    }

    area() {
        return (this.base1 + this.base2) * this.height / 2;
    }
}

console.log("trapezoid");
console.log(new Trapezoid(2, 8, 13, "wide"));
console.log(new Trapezoid(2, 2, 2, "square").area());
console.log(new Trapezoid(9, 2, 3, "tall").area());


//zad 4
function largestOf(rectangle, triangle, trapezoid) {
    let largest = [rectangle];

    let largestArea = largest[0].area();
    let triangleArea = triangle.area();

    if (triangleArea > largestArea)
        largest = [triangle];
    else if (triangleArea == largestArea)
        largest.push(triangle);
    
    largestArea = largest[0].area();
    let trapezoidArea = trapezoid.area();

    if (trapezoidArea > largestArea)
        largest = [trapezoid];
    else if (trapezoidArea == largestArea)
        largest.push(trapezoid);
    
    return largest;
}

console.log("largestOf");
console.log(largestOf(new Rectangle(2, 2.5, "a"), new Triangle(5, 5, "b"), new Trapezoid(1, 1, 1, "c")));
console.log(largestOf(new Rectangle(1, 1, "d"), new Triangle(1, 1, "e"), new Trapezoid(1, 1, 1, "f")));
console.log(largestOf(new Rectangle(1, 2, "g"), new Triangle(2, 2, "h"), new Trapezoid(2, 1, 1, "i")));
