# test doubles in cryptogram and return their positions and eventual correlation if the double is regular
def testDouble(cryptogram):
    doubles = []
    done = []
    for i in range(len(cryptogram)-1):
        if (cryptogram[i]==cryptogram[i+1]) and (cryptogram[i] not in done):
            doubles.append((cryptogram[i],i))
            done.append(cryptogram[i])
    return doubles

# compute the distribution of the doubles
def freqDouble(cryptogram):
    freqs = []
    done = []
    doubles = testDouble(cryptogram)
    for d in doubles:
        if d[0] in done:
            pass
        s = d[0]*2
        parts = cryptogram.split(s)
        freq = []
        for p in parts:
            freq.append(len(p))
        freqs.append((d[0], freq))
        done.append(d[0])
    return freqs

def splitDouble(cryptogram):
    doubles = testDouble(cryptogram)
    done = []
    parts = []
    for do in doubles:
        d = do[0]
        if d not in done:
            parted = cryptogram.split(d)
            part = []
            for p in parted:
                part.append((p, len(p)))
            parts.append(part)
            done.append(d)
    return parts

# test possible common starts
def testStart(cryptogram, n):
    starts = []
    for i in range(len(cryptogram)-(n-1)):
        for j,p in enumerate(cryptogram[i+n:-(n-1)]):
            if cryptogram[i:i+n]==cryptogram[j:j+n]:
                starts.append(cryptogram[i:i+n])
    return starts

def splitStart(cryptogram, n):
    starts = testStart(cryptogram, n)
    parts = []
    if len(starts)==1:
        parted = cryptogram.split(starts[1])
        for p in parted:
            parts.append((p, len(p)))
    return parts

def testStart2(cryptogram, n):
    starts = []
    for i in range(len(cryptogram)-(n-1)):
        s = cryptogram[i:i+n]
        if (s in cryptogram[i+n:len(cryptogram)]) and (s not in starts):
            starts.append(s)
    return starts

def splitStart2(cryptogram, n):
    starts = testStart2(cryptogram, n)
    possible = []
    for s in starts:
        parts = cryptogram.split(s)
        possible.append((s, parts))
    return possible

def letterGroups(cryptogram, n):
    groups = []
    for i in range(n):
        group = []
        for j in range(len(cryptogram)):
            if j%n==i:
                group.append(cryptogram[j])
        groups.append(group)
    return groups

def clusterLetter(cryptogram, n):
    groups = letterGroups(cryptogram, n)
    clusters = []
    for g in groups:
        cluster = dict()
        for l in g:
            if l in cluster.keys():
                cluster[l] += 1
            else:
                cluster[l] = 1
        clusters.append(cluster)
    return clusters

def analyseClusters(cryptogram, n):
    rates = []
    clusters = clusterLetter(cryptogram, n)
    for c in clusters:
        total = sum(c.values())
        rate = dict()
        for l in c.keys():
            rate[l] = round(((c[l]/total)*100), 3)
        rates.append(rate)
    return rates

def icProbability(cryptogram):
    stats = dict()
    for l in cryptogram:
        if l in stats.keys():
            stats[l] += 1
        else:
            stats[l] = 1
    n = len(cryptogram)
    ic = 0
    for l in stats.keys():
        ic += (stats[l]*(stats[l]-1))/(n*(n-1))
    return ic

def checkKey(cryptogram, n):
    clusters = clusterLetter(cryptogram, n)
    ics = []
    for c in clusters:
        n = sum(c.values())
        ic = 0
        for l in stats.keys():
            ic += (c[l]*(c[l]-1))/(n*(n-1))
        ics.append(ic)
    avg = sum(ics)/len(ics)
    for ic in ics:
        if (ic>avg+0.01) or (ic<avg-0.01):
            return False
    return True

def verifyEncryption(cryptogram, plaintext):
    ic_c = icProbability(cryptogram)
    ic_p = icProbability(plaintext)
    if ic_c==ic_p:
        return True
    return False

def breakCipher(cryptogram):
    return True
