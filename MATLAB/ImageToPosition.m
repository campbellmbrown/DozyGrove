% Setup
clear;clc;
tile_size = 10;

% Reading the image
img = imread('grove_dark_green_trees_1.png');

idx = 1;

% Generating positions of all black pixels in the image
for i = 1:size(img, 1)
    for j = 1:size(img, 2)
        if img(i, j) == 0
            positions(idx, :) = [(j-1)*tile_size, (i-1)*tile_size];
            idx = idx + 1;
        end
    end
end

% Converting the positions to a string to copy into a JSON editor
JSONstr = '[';
for i = 1:size(positions, 1)
    JSONstr = strcat(JSONstr,...
        num2str(positions(i, 1)),...
        ',',...
        num2str(positions(i, 2)),...
        '],[');
end
JSONstr = JSONstr(1:length(JSONstr)-2);
disp(JSONstr)

% TODO: Add full JSON formatting 
