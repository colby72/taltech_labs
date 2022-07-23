from math import sqrt
from random import choice

""" Tool functions (mathematical) used for the main problem """

# returns the gcd of a & b
def gcd(a, b):
    if a<b:
        (a,b) = (b,a)
    if b==0:
        return a
    return gcd(a%b, b)

# solves a.x = b [m] and returns x
def inverse(a, b, m):
    if (gcd(a,m)!=1):
        return -1
    x=1
    while (x*a)%m!=b:
        x += 1
    return x

# returns True if n is a prime number, False otherwise
def isPrime(n):
    i=2
    s = sqrt(n)
    while i<s:
        if n%i==0:
            return False
        i += 1
    return True

# returns a table of all prime numbers smaller than n
def primeGen(n):
    primes = [2]
    i = 3
    while i<n:
        if isPrime(i):
            primes.append(i)
        i += 2
    return primes

""" Core functions used to solve the main assignement"""

# returns a random prime number between a & b
def randomGen(a, b):
    primes = primeGen(b)
    p = choice(primes)
    while p<=a:
        p = choice(primes)
    return p

# returns all four square roots of 1 mod n
def squareRoots(n):
    sr = []
    i = 1
    while i<n:
        if (i**2)%n==1:
            sr.append(i)
        i += 1
    return sr

""" Main program solving the assignement """

# generate two different random primes p & q and compute n
p = randomGen(1000, 2000)
q = randomGen(1000, 2000)
while p==q:
    q = randomGen(1000, 2000)
n = p*q

# compute public exponent e
m = (p-1)*(q-1)
e = 2
while gcd(m, e)!=1:
    e += 1

# compute private exponent d
d = inverse(e, 1, m)

# show all computed information
print("Random primes computed: p=", p, " & q=", q, sep="")
print("Modulus: n=", n, sep="")
print("\nPublic exponent: e=", e, sep="")
print("Private exponent: d=", d, sep="")

# simulation with student number
s = 194633
y = (s**e)%n
x = (s**d)%n

print("\n------------------------------------------\n")
print("Student code : ", s)
print("Computed numbers: y=", y, " & x=", x, sep="")

x0 = (y**d)%n
y0 = (x**e)%n

print("\nInverse computations:")
print("y^d mod n = ", x0)
print("x^e mod n = ", y0)

# compute square roots of 1 mod n
sr1 = squareRoots(p)
sr2 = squareRoots(q)
print("\n------------------------------------------\n")
print("Square roots of 1 modulo n: ")
print("x1 =(", sr1[0], ", ", sr2[0], ")", sep="")
print("x2 =(", sr1[0], ", ", sr2[1], ")", sep="")
print("x3 =(", sr1[1], ", ", sr2[0], ")", sep="")
print("x4 =(", sr1[1], ", ", sr2[1], ")", sep="")
