a=load('.\f7.star.3.diversity.txt');
b=load('.\f7.ring.3.diversity.txt');
c=load('.\f7.fourClusters.3.diversity.txt');
d=load('.\f7.vonNeumann.3.diversity.txt');
e=load('.\f7.socialStar.3.diversity.txt');
f=load('.\f7.socialRing.3.diversity.txt');
g=load('.\f7.cognitive.3.diversity.txt');

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