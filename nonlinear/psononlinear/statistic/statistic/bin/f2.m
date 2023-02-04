a=load('.\f2.star.1.diversity.txt');
b=load('.\f2.ring.1.diversity.txt');
c=load('.\f2.fourClusters.1.diversity.txt');
d=load('.\f2.vonNeumann.1.diversity.txt');
e=load('.\f2.socialStar.1.diversity.txt');
f=load('.\f2.socialRing.1.diversity.txt');
g=load('.\f2.cognitive.1.diversity.txt');

semilogy(a, '-.b');
hold on
semilogy(b, '-r');
semilogy(c, '--k');
semilogy(d, '--g');
%semilogy(e, '-c');
semilogy(f, '-k');
semilogy(g, '--r');

%fontsize = legend('star', 'ring', 'fourClusters', 'vonNeumann', 'socialStar', 'socialRing', 'cognition',0);
fontsize = legend('star', 'ring', 'fourClusters', 'vonNeumann', 'socialRing', 'cognition',0);

set(fontsize, 'FontSize', 14);