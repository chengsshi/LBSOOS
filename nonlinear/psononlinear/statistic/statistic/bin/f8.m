a=load('.\f8.star.2.diversity.txt');
b=load('.\f8.ring.2.diversity.txt');
c=load('.\f8.fourClusters.2.diversity.txt');
d=load('.\f8.vonNeumann.2.diversity.txt');
e=load('.\f8.socialStar.2.diversity.txt');
f=load('.\f8.socialRing.2.diversity.txt');
g=load('.\f8.cognitive.2.diversity.txt');

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