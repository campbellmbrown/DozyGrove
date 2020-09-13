% Setup
clear;clc;

% Reading the image
img = imread('grove_patch.png');

idx = 1;

% Generating positions of all black pixels in the image
for i = 1:size(img, 1)
    for j = 1:size(img, 2)
        if img(i, j) == 1
            positions(idx, :) = [(j-1), (i-1)];
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
