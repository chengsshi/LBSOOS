a=load('.\f3.star.1.diversity.txt');
b=load('.\f3.ring.1.diversity.txt');
c=load('.\f3.fourClusters.1.diversity.txt');
d=load('.\f3.vonNeumann.1.diversity.txt');
e=load('.\f3.socialStar.1.diversity.txt');
f=load('.\f3.socialRing.1.diversity.txt');
g=load('.\f3.cognitive.1.diversity.txt');

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