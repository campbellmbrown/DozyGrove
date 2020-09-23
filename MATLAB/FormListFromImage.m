function [JSONstr] = FormListFromImage(imgName, prefix, fileType)

    JSONstr = '[';
    % Reading the image
    img = imread(strcat(prefix, imgName, fileType));
    % Reading the positions of all black pixels in the image
    idx = 1;
    for i = 1:size(img, 1)
        for j = 1:size(img, 2)
            if img(i, j) == 1
                JSONstr = strcat(JSONstr, '[', num2str(i - 1), ...
                ',', num2str(j - 1), '],');
            end
        end
    end
    
    % Removing the last comma
    JSONstr = strip(JSONstr, 'right', ',');
    % Adding the closing bracket
    JSONstr = strcat(JSONstr, ']');
end